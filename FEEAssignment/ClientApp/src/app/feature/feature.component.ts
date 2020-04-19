import { Component, Inject, OnInit } from '@angular/core';
import { Feature } from '../models/feature';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-feature',
  templateUrl: './feature.component.html',
  styleUrls: ['./feature.component.css']
})
export class FeatureComponent implements OnInit {
  http: HttpClient;
  baseUrl: string;
  features: Feature[];
  canModify: Boolean;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
    this.http = _http;
  }
  ngOnInit() {
    
    this.http.get<Feature[]>(this.baseUrl + 'api/features').subscribe(result => {
      this.features = result;
    }, error => {
      console.log(error)
    }, () => {
      //this.isLoading = false;
    });
    
    this.http.get<Boolean>(this.baseUrl + 'api/modify').subscribe(result => {
      this.canModify = result;
    }, error => {
      console.log(error)
    }, () => {
      //this.isLoading = false;
    });
    

  }

}
