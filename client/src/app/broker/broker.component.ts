import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-broker',
  templateUrl: './broker.component.html',
  styleUrls: ['./broker.component.scss']
})
export class BrokerComponent implements OnInit {
  brokerForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private  toast: ToastrService) { }

  ngOnInit(): void {
    this.brokerFormBuilder();
  }

  brokerFormBuilder(){
    this.brokerForm = this.formBuilder.group({
      name: [null],
      email: [null],
      phoneNumber: [null],
      provider: [null],
      attachments: [null]
    });
  }

  uploadFile(event) {
    const file = (event.target as HTMLInputElement).files[0];
    this.brokerForm.patchValue({
      attachments: file
    });
    this.brokerForm.get('attachments').updateValueAndValidity();
  }

  onSubmit() {
    console.log(this.brokerForm.value);
    const formData = new FormData();
    formData.append('name', this.brokerForm.get('name').value);
    formData.append('email', this.brokerForm.get('email').value);
    formData.append('phoneNumber', this.brokerForm.get('phoneNumber').value);
    formData.append('provider', this.brokerForm.get('provider').value);
    formData.append('attachments', this.brokerForm.get('attachments').value);

    return this.httpClient.post('http://localhost:5000/api/email/broker', formData).subscribe(res => {
      console.log(res);
      this.toast.success('Thank you for contacting us');
    }, error => {
      console.log(error);
      this.toast.error(error);
    });
  }
}
