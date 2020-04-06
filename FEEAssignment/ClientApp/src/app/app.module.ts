import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LoginComponent } from './login/login.component';
<<<<<<< HEAD
import { FeatureComponent } from './feature/feature.component';
=======
import { LoginComponent as asd} from '../api-authorization/login/login.component';
>>>>>>> 43f17a7c8837195fc4fb6f1aaad4befcf8dec0a0

@NgModule({
  declarations: [
    AppComponent,    
    HomeComponent,        
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    FeatureComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthorizeGuard] },
      { path: 'login', component: LoginComponent, pathMatch: 'full' },
      { path: 'asd/:loginaction', component: asd},      
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
