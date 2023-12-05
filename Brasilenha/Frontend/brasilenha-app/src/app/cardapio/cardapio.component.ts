import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';

import { HttpClient } from '@angular/common/http';
import { NavbarComponent } from '../navbar/navbar.component';
import { CardsComponent } from '../cards/cards.component';

import { PoductData } from '../product-data';
import { ApiProductService } from '../api-product.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cardapio',
  standalone: true,
  imports: [CommonModule, NavbarComponent, CardsComponent, MatDialogModule, FormsModule, MatInputModule, MatFormFieldModule],
  templateUrl: './cardapio.component.html',
  styleUrl: './cardapio.component.css'
})
export class CardapioComponent implements OnInit {
  
  constructor (public dialog: MatDialog) { }
  ngOnInit(): void {
    this.setOptions()
  }

  @Input()
  nomeDoCard: string = "kk"

  option1 = () => { }
  option2 = () => { }
  option3 = () => { }

 setOptions()
 {
    let self = this;
    this.option1 = () =>
    {
      self.dialog.open(NovoPratoDialog);
    };
    this.option2 = () =>
    {

    };

 }

}

@Component({
  selector: 'app-novo-prato-dialog',
  standalone: true,
  imports: [CommonModule,MatFormFieldModule, FormsModule, NavbarComponent, CardsComponent, MatFormFieldModule, MatInputModule, MatDialogModule],
  templateUrl: './novo-prato-dialog.component.html',
  styleUrl: './cardapio.component.css'
})
export class NovoPratoDialog
{
  nomeProduto: string = '';
  descricao: string = '';
  valor: number = 0;

  constructor(
    public dialogRef: MatDialogRef<NovoPratoDialog>,
    private product: ApiProductService,
    private http: HttpClient,
    private router: Router,
  ) {}

  criar() {

    this.http.post('http://localhost:5083/product/imagem', this.formData)
    .subscribe((result: any)  =>
    {
      this.product.register({
        nomeProduto: this.nomeProduto,
        valor: this.valor,
        descricao: this.descricao,
        imagem: result.imagem
      // }, (response:any) => {
      //   this.dialogRef.close()
      })
    })
}

  //   this.product.register({
  //     nomeProduto: this.nomeProduto,
  //     descricao: this.descricao,
  //     imagem: "",
  //     valor: this.valor
  //   });
  //   this.dialogRef.close();
  // }

  private formData = new FormData()
  uploadFile = (files:any) => {
    if(files.length === 0){
      return;
    }
    let fileToUpload = <File>files[0];
    this.formData = new FormData();
    this.formData.append('file', fileToUpload, fileToUpload.name);

    var jwt = sessionStorage.getItem('jwt');
    if(jwt == null)
      return
    this.formData.append('jwt', jwt)
  }
}


