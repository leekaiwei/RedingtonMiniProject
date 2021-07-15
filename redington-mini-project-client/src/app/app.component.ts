import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) {
    
  }

  public ngOnInit(): void {
    this.form = this.formBuilder.group({
      probabilityOne: [null, Validators.compose([Validators.required, Validators.min(0), Validators.max(1)])],
      probabilityTwo: [null, Validators.compose([Validators.required, Validators.min(0), Validators.max(1)])],
      probabilityFunction: [null, Validators.required],
    });

    this.httpClient.get<string[]>(`${this.url}/probabilityFunctions`).subscribe(probabilityFunctions => this.probabilityFunctions = probabilityFunctions)
  }

  public calculate(): void {
    this.error = null;

    const data = this.form.getRawValue();

    const httpParams = new HttpParams()
      .append('probabilityOne', data.probabilityOne)
      .append('probabilityTwo', data.probabilityTwo)
      .append('probabilityFunction', data.probabilityFunction);

    this.httpClient.get<string>(`${this.url}/probability`, { params: httpParams })
      .subscribe(
        result => this.result = parseFloat(result),
        error => this.error = error.message
      );
  }
}
