import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { User } from '../models/user.models';

@Component({
  selector: 'app-registration',
  imports: [ReactiveFormsModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  title = 'registration';

  form = new FormGroup({
    name: new FormControl("", Validators.required),
    email: new FormControl("", Validators.required),
    password: new FormControl("", Validators.required),
  })

  constructor(private userService: UserService){
    
  }

  registrateUser(){
    if (!this.form.valid){
      return
    }

    const user: User = this.form.getRawValue();
    this.form.reset();
    this.userService.registrateUserFromApi(user);
  }
  
}
