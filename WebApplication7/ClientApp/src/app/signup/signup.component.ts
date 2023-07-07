
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: 'signup.component.html',
  styleUrls: ['signup.component.css']
})
export class SignUpComponent {
  signupForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.signupForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get username() {
    return this.signupForm.get('username');
  }

  get password() {
    return this.signupForm.get('password');
  }

  onSignUp() {
    // Call the signup method of the authentication service
    this.authService
      .signUp(this.username.value, this.password.value)
      .subscribe(
        () => {
          // Signup successful, navigate to the desired page
          this.router.navigate(['/dashboard']);
        },
        (error) => {
          // Handle signup error
          console.log(error);
        }
      );
  }
}
