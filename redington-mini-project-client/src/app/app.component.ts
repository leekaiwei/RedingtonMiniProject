import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  form!: FormGroup;
  result!: number;
  probabilityFunctions!: string[];
  error!: string | null;

  private readonly url = 'http://localhost:14764';

  private readonly probabilityValidators!: ValidatorFn | null; 

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) {
    this.probabilityValidators = Validators.compose([Validators.required, Validators.min(0), Validators.max(1)]);
  }

  public ngOnInit(): void {
    this.form = this.formBuilder.group({
      probabilityA: [null, this.probabilityValidators], 
      probabilityB: [null, this.probabilityValidators],
      probabilityFunction: [null, Validators.required],
    });

    this.httpClient.get<string[]>(`${this.url}/probabilityFunctions`).subscribe(probabilityFunctions => this.probabilityFunctions = probabilityFunctions)
  }

  public calculate(): void {
    this.error = null;

    const data = this.form.getRawValue();

    const httpParams = new HttpParams()
      .append('probabilityA', data.probabilityA)
      .append('probabilityB', data.probabilityB)
      .append('probabilityFunction', data.probabilityFunction);

    this.httpClient.get<string>(`${this.url}/probability`, { params: httpParams })
      .subscribe(
        result => this.result = parseFloat(result),
        error => this.error = error.message
      );
  }
}
