import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {HttpClient} from "@angular/common/http";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-help-donation',
  templateUrl: './help-donation.component.html',
  styleUrls: ['./help-donation.component.scss']
})
export class HelpDonationComponent implements OnInit {
  customClass = 'customClass';
  helpForm: FormGroup;
  province = [
    'Gauteng',
    'Free-State',
    'Mpumalanga',
    'Limpopo',
    'Kwa-Zulu Natal',
    'North-West',
    'Northern Cape',
    'Western Cape',
    'Eastern Cape'
  ];
  employment = [
    'Employed',
    'Unemployed'
  ];

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private toast: ToastrService) { }

  ngOnInit(): void {
    this.helpFormBuilder();
  }

  helpFormBuilder(){
    this.helpForm = this.formBuilder.group({
      name: [null],
      email: [null],
      phoneNumber: [null],
      idNumber: [null],
      pensionerConfirmation: [null],
      numberOfFamilyMembers: [null],
      province: [null],
      employmentStatus: [null],
      message: [null]
    });
  }

  onSubmit() {
    const formData = new FormData();

    formData.append('name', this.helpForm.get('name').value);
    formData.append('email', this.helpForm.get('email').value);
    formData.append('phoneNumber', this.helpForm.get('phoneNumber').value);
    formData.append('idNumber', this.helpForm.get('idNumber').value);
    formData.append('pensionerConfirmation', this.helpForm.get('pensionerConfirmation').value);
    formData.append('numberOfFamilyMembers', this.helpForm.get('numberOfFamilyMembers').value);
    formData.append('province', this.helpForm.get('province').value);
    formData.append('employmentStatus', this.helpForm.get('employmentStatus').value);
    formData.append('message', this.helpForm.get('message').value);

    return this.http.post('http://localhost:5000/api/email/donation', formData).subscribe(res => {
      console.log(res);
      this.toast.success('Thank you for contacting us');
    }, error => {
      console.log(error);
      this.toast.error(error);
    });
  }
}
