import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/';
  validationErrors: string[] = [];

  constructor(private http: HttpClient) { }

  get404Error() {
    this.http.get(this.baseUrl + 'error/not-found').subscribe(resp => {
      console.log(resp);
    }, error => {
      console.log(error);
    });
  }

  get400Error() {
    this.http.get(this.baseUrl + 'error/bad-request').subscribe(resp => {
      console.log(resp);
    }, error => {
      console.log(error);
    });
  }

  get500Error() {
    this.http.get(this.baseUrl + 'error/server-error').subscribe(resp => {
      console.log(resp);
    }, error => {
      console.log(error);
    });
  }

  get401Error() {
    this.http.get(this.baseUrl + 'error/auth').subscribe(resp => {
      console.log(resp);
    }, error => {
      console.log(error);
    });
  }

  get400ValidationError() {
    this.http.post(this.baseUrl + 'account/register', {}).subscribe(resp => {
      console.log(resp);
    }, error => {
      console.log(error);
      this.validationErrors = error;
    });
  }


  ngOnInit(): void {
  }

}
