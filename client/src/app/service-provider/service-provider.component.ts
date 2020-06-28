import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-service-provider',
  templateUrl: './service-provider.component.html',
  styleUrls: ['./service-provider.component.scss']
})
export class ServiceProviderComponent implements OnInit {
  serviceProviderForm: FormGroup;
  involvement = [
    'Roadside',
    'Home',
    'Medical'
  ];

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private  toast: ToastrService) { }

  ngOnInit(): void {
    this.serviceFormBuilder();
  }

  serviceFormBuilder(){
    this.serviceProviderForm = this.formBuilder.group({
      name: [null],
      companyName: [null],
      website: [null],
      email: [null],
      number: [null],
      message: [null],
      involvement: [null],
      attachments: [null]
    });
  }

  uploadFile(event) {
    const file = (event.target as HTMLInputElement).files[0];
    this.serviceProviderForm.patchValue({
      attachments: file
    });
    this.serviceProviderForm.get('attachments').updateValueAndValidity();
  }

  onSubmit() {
    console.log(this.serviceProviderForm.value);
    const formData = new FormData();
    formData.append('name', this.serviceProviderForm.get('name').value);
    formData.append('companyName', this.serviceProviderForm.get('companyName').value);
    formData.append('website', this.serviceProviderForm.get('website').value);
    formData.append('email', this.serviceProviderForm.get('email').value);
    formData.append('number', this.serviceProviderForm.get('number').value);
    formData.append('message', this.serviceProviderForm.get('message').value);
    formData.append('involvement', this.serviceProviderForm.get('involvement').value);
    formData.append('attachments', this.serviceProviderForm.get('attachments').value);

    return this.httpClient.post('http://localhost:5000/api/email/serviceProvider', formData).subscribe(res => {
      console.log(res);
      this.toast.success('Thank you for contacting us');
    }, error => {
      console.log(error);
      this.toast.error(error);
    });
  }
}
