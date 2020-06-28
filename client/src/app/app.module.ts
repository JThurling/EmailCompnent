import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactComponent } from './contact/contact.component';
import {ToastrModule} from 'ngx-toastr';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { HelpDonationComponent } from './help-donation/help-donation.component';
import { IntermediaryBrokerComponent } from './intermediary-broker/intermediary-broker.component';
import { ServiceProviderComponent } from './service-provider/service-provider.component';
import { BrokerComponent } from './broker/broker.component';
import {AccordionModule} from "ngx-bootstrap/accordion";
import {ModalModule} from "ngx-bootstrap/modal";
import { WorkForUsComponent } from './work-for-us/work-for-us.component';



@NgModule({
  declarations: [
    AppComponent,
    ContactComponent,
    HelpDonationComponent,
    IntermediaryBrokerComponent,
    ServiceProviderComponent,
    BrokerComponent,
    WorkForUsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    AccordionModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
