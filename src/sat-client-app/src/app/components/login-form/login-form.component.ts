import { Component, OnInit } from '@angular/core';

import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {
  steamId = new FormControl('')

  constructor() { }

  ngOnInit() {
  }

}
