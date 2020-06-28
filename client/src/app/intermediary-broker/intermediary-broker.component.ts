import {Component, OnInit, TemplateRef} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {ToastrService} from 'ngx-toastr';
import {BsModalRef, BsModalService} from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-intermediary-broker',
  templateUrl: './intermediary-broker.component.html',
  styleUrls: ['./intermediary-broker.component.scss']
})
export class IntermediaryBrokerComponent implements OnInit {
  intermediateBrokerForm: FormGroup;
  // Tab Steps
  stepOneOpen = true;
  stepTwoOpen = false;
  stepThreeOpen = false;
  stepFourOpen = false;
  stepFiveOpen = false;
  // Modal
  modalRef: BsModalRef;


  constructor(private formBuilder: FormBuilder,
              private httpClient: HttpClient,
              private  toast: ToastrService,
              private modalService: BsModalService) { }

  ngOnInit(): void {
    this.intermediaryFormBuilder();
  }

  intermediaryFormBuilder(){
    this.intermediateBrokerForm = this.formBuilder.group({
      name: [null],
      email: [null],
      phoneNumber: [null],
      attachments: [null]
    });
  }

  uploadFile(event) {
    const file = (event.target as HTMLInputElement).files[0];
    this.intermediateBrokerForm.patchValue({
      attachments: file
    });
    this.intermediateBrokerForm.get('attachments').updateValueAndValidity();
  }

  onSubmit() {
    console.log(this.intermediateBrokerForm.value);
    const formData = new FormData();
    formData.append('name', this.intermediateBrokerForm.get('name').value);
    formData.append('email', this.intermediateBrokerForm.get('email').value);
    formData.append('phoneNumber', this.intermediateBrokerForm.get('phoneNumber').value);
    formData.append('attachments', this.intermediateBrokerForm.get('attachments').value);

    return this.httpClient.post('http://localhost:5000/api/email/intermediaryBroker', formData).subscribe(res => {
      console.log(res);
      this.toast.success('Thank you for contacting us');
    }, error => {
      console.log(error);
      this.toast.error(error);
    });
  }

  stepOne() {
    this.stepOneOpen = true;
    this.stepTwoOpen = false;
    this.stepThreeOpen = false;
    this.stepFourOpen = false;
    this.stepFiveOpen = false;
  }

  stepTwo() {
    this.stepOneOpen = false;
    this.stepTwoOpen = true;
    this.stepThreeOpen = false;
    this.stepFourOpen = false;
    this.stepFiveOpen = false;
  }

  stepThree() {
    this.stepOneOpen = false;
    this.stepTwoOpen = false;
    this.stepThreeOpen = true;
    this.stepFourOpen = false;
    this.stepFiveOpen = false;
  }

  stepFour() {
    this.stepOneOpen = false;
    this.stepTwoOpen = false;
    this.stepThreeOpen = false;
    this.stepFourOpen = true;
    this.stepFiveOpen = false;
  }

  stepFive() {
    this.stepOneOpen = false;
    this.stepTwoOpen = false;
    this.stepThreeOpen = false;
    this.stepFourOpen = false;
    this.stepFiveOpen = true;
  }

  onModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, Object.assign({}, {
      class: 'modal-lg border-0 shadow mt-5'}));
  }
}
