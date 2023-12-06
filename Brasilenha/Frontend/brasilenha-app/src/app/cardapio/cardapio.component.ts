import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import {
  MatDialog,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';

import { HttpClient } from '@angular/common/http';
import { NavbarComponent } from '../navbar/navbar.component';
import { CardsComponent } from '../cards/cards.component';

import { PoductData } from '../product-data';
import { ApiProductService } from '../api-product.service';
import { CupomService } from '../api-cupom.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cardapio',
  standalone: true,
  imports: [
    CommonModule,
    NavbarComponent,
    CardsComponent,
    MatDialogModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
  ],
  templateUrl: './cardapio.component.html',
  styleUrl: './cardapio.component.css',
})
export class CardapioComponent implements OnInit {
  constructor(public dialog: MatDialog) {}
  ngOnInit(): void {
    this.setOptions();
  }

  @Input()
  nomeDoCard: string = 'kk';

  option1 = () => {};
  option2 = () => {};
  option3 = () => {};

  setOptions() {
    let self = this;
    this.option1 = () => {
      self.dialog.open(NovoPratoDialog);
    };
    this.option2 = () => {
      self.dialog.open(NovoCupomDialog);
    };
  }
}

@Component({
  selector: 'app-novo-prato-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    FormsModule,
    NavbarComponent,
    CardsComponent,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
  ],
  templateUrl: './novo-prato-dialog.component.html',
  styleUrl: './cardapio.component.css',
})
export class NovoPratoDialog {
  nomeProduto: string = '';
  descricao: string = '';
  valor: number = 0;
  private formData = new FormData();

  constructor(
    public dialogRef: MatDialogRef<NovoPratoDialog>,
    private product: ApiProductService,
    private http: HttpClient,
    private router: Router
  ) {}

  criar() {
    console.log(this.formData.get('file'));
    this.product.uploadImage(this.formData).subscribe({
      next: (res) => {
        this.product.register({
          nomeProduto: this.nomeProduto,
          valor: this.valor,
          descricao: this.descricao,
          idImg: res.imgId,
        });
        this.dialogRef.close();
      },
    });
  }

  uploadFile = (files: any) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    this.formData = new FormData();
    this.formData.append('file', fileToUpload, fileToUpload.name);
// 
    // var jwt = sessionStorage.getItem('jwt');
    // if (jwt == null)
    //   return;
    this.formData.append('jwt', "blablabla"); // trocar "blablabla" por jwt

    console.log(files);
  };
}

@Component({
  selector: 'app-novo-cupom-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    FormsModule,
    NavbarComponent,
    CardsComponent,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
  ],
  templateUrl: './novo-cupom-dialog.component.html',
  styleUrl: './cardapio.component.css',
})
export class NovoCupomDialog {
  codigo: string = '';
  valor: string = '';

  constructor(
    public dialogRef: MatDialogRef<NovoPratoDialog>,
    private client: CupomService
  ) {}

  criar() {
    this.client.register({
      codigo: this.codigo,
      valor: this.valor,
    });

    this.dialogRef.close();
  }
}
