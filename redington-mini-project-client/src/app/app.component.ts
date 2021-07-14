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

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) {

  }

  public ngOnInit(): void {
    this.form = this.formBuilder.group({
      probabilityOne: [null, Validators.required],
      probabilityTwo: [null, Validators.required],
      probabilityFunction: [null, Validators.required],
    });
  }

  public calculate(): void {
    const data = this.form.getRawValue();

    const httpParams = new HttpParams()
      .append('probabilityOne', data.probabilityOne)
      .append('probabilityTwo', data.probabilityTwo)
      .append('probabilityFunction', data.probabilityFunction);

    this.httpClient.get('http://localhost:14764/probability', { params: httpParams })
      .subscribe(result => this.result = +result);
  }
}
