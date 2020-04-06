import { Component } from '@angular/core';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  userLoggedIn: boolean = false;
  constructor(private authorize: AuthorizeService) { 
      this.authorize.isAuthenticated().subscribe(x => {
        this.userLoggedIn = x;
      })    
  }

}
