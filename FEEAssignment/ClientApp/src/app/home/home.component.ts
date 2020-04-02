import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Home } from '../models/home';
import { Course } from '../models/course';
import { Feature } from '../models/feature';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  http: HttpClient;
  baseUrl: string;
  isLoading: boolean;
  userName: string;
  userRole: string;
  courses: Course[];
  features: Feature[];

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
    this.http = _http;
  }

  ngOnInit() {
    this.isLoading = true;
    this.http.get<Home>(this.baseUrl + 'api/home').subscribe(result => {
      this.userName = result.userId;
      this.userRole = result.userRole;
    }, error => {
      console.log(error)
    }, () => {     
    });

    this.http.get<Course[]>(this.baseUrl + 'api/courses').subscribe(result => {
      debugger;
      this.courses = result;      
    }, error => {
      console.log(error)
    }, () => {
      this.isLoading = false;
    });

    this.http.get<Feature[]>(this.baseUrl + 'api/features').subscribe(result => {
      this.features = result;
    }, error => {
      console.log(error)
    }, () => {
      //this.isLoading = false;
    });
  }
}
