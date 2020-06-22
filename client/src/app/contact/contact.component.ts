import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  requestTypes = ['Claims', 'Feedback', 'Help Request'];
  contactForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private toast: ToastrService) {
  }

  ngOnInit(): void {
    this.contactFormBuilder();
  }

  contactFormBuilder(){
    this.contactForm = this.formBuilder.group({
      name: [null],
      email: [null],
      requestType: [null],
      message: [null],
      attachments: [null]
    });
  }

  onSubmit() {
    console.log(this.contactForm.value);

    const formData = new FormData();
    formData.append('name', this.contactForm.get('name').value);
    formData.append('email', this.contactForm.get('email').value);
    formData.append('requestType', this.contactForm.get('requestType').value);
    formData.append('message', this.contactForm.get('message').value);
    formData.append('attachments', this.contactForm.get('attachments').value);

    return this.http.post('http://localhost:5000/api/email', formData).subscribe(res => {
      console.log(res);
      this.toast.success('Thank you for contacting us');
    }, error => {
      console.log(error);
      this.toast.error(error);
    });

  }

  uploadFile(event) {
    const file = (event.target as HTMLInputElement).files[0];
    this.contactForm.patchValue({
      attachments: file
    });
    this.contactForm.get('attachments').updateValueAndValidity();
  }
}
