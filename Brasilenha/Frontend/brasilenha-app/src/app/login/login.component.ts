import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { ClientServiceService } from '../client-service.service';

import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
    constructor (public dialog: MatDialog,
    private client: ClientServiceService,
    private http: HttpClient) {}

    username: string = ""
    // email: string = ""
    senha: string = ""

    logar()
    {
      this.client.login({
        login: this.username,
        password: this.senha
      }, (result: any) => {
        if(result == null)
        {
          alert("senha e(ou) usuário incorreto(s)!")
        }
        else
        {
          sessionStorage.setItem('jwt', JSON.stringify(result))
        }
      })
    }

}
