import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';

import { ClientServiceService } from '../client-service.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, MatInputModule, MatDialogModule, MatFormFieldModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
    constructor (public dialog: MatDialog,
    private client: ClientServiceService,
    private http: HttpClient, 
    private router: Router) {}

    username: string = ""
    senha: string = ""
    isAdm: boolean = false

    logar()
    {
      this.client.login({
        login: this.username,
        email: "",
        senha: this.senha,
        isAdm: this.isAdm
      }, (result: any) => {
        if(result == null)
        {
          alert("senha e(ou) usuário incorreto(s)!")
        }
        else
        {
          sessionStorage.setItem('jwt', JSON.stringify(result))

          console.log("result: ", result);

            this.router.navigate(['ClientApp']);

        }
      })
    }

    registrar()
    {
      this.dialog.open(NewUserDialog);
    }
}

@Component({
  selector: 'app-new-user-dialog',
  standalone: true,
  imports: [CommonModule, FormsModule, MatInputModule],
  templateUrl: './new-user-dialog.component.html',
  styleUrl: './login.component.css'
})
export class NewUserDialog
{
  username: string = ""
  email: string = ""
  senha: string = ""
  isAdm: boolean = false
  confirmasenha: string = ""

  constructor(public dialogRef: MatDialogRef<NewUserDialog>,
    private client: ClientServiceService) {}

    criar()
    {
      this.client.register({
        login: this.username,
        email: this.email,
        senha: this.senha,
        isAdm: this.isAdm
      })

      this.dialogRef.close()
    }
}
