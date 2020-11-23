import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

import { FuseConfigService } from "@fuse/services/config.service";
import SignIn from 'app/model/signIn';
import { UserService } from 'app/services/user.service';
import swal from "sweetalert2";

@Component({
    selector: "login",
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.scss"],
    encapsulation: ViewEncapsulation.None,
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    constructor(
        private fuseConfigService: FuseConfigService,
        private formBuilder: FormBuilder,
        private userService: UserService
    ) {
        this.fuseConfigService.config = {
            layout: {
                navbar: {
                    hidden: true,
                },
                toolbar: {
                    hidden: true,
                },
                footer: {
                    hidden: true,
                },
                sidepanel: {
                    hidden: true,
                },
            },
        };
    }

    ngOnInit(): void {
        this.loginForm = this.formBuilder.group({
            email: ["", [Validators.required, Validators.email]],
            password: ["", Validators.required],
        });
    }

    login(loginForm){
        if(loginForm.isValid == false) return;

        let email = this.loginForm.get("email").value;
        let password = this.loginForm.get("password").value; 
        let signIn = new SignIn();
        signIn.email = email;
        signIn.password=password;

        this.userService.authenticate(signIn).subscribe(result=>{})
    }
}
