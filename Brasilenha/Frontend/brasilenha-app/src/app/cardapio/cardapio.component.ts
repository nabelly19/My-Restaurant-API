import { Component, Input } from '@angular/core';
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
  imports: [CommonModule, NavbarComponent, CardsComponent,MatDialogModule, FormsModule, MatInputModule, MatFormFieldModule],
  templateUrl: './cardapio.component.html',
  styleUrl: './cardapio.component.css'
})
export class CardapioComponent {
  
  constructor (
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router,
    
    ) { }

  @Input()
  nomeDoCard: string = ""

 option1()
 {
   this.dialog.open(NovoPratoDialog);
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
  imagem = ""

  constructor(
    public dialogRef: MatDialogRef<NovoPratoDialog>,
    private product: ApiProductService
  ) {}

  criar() {
    this.product.register({
      nomeProduto: this.nomeProduto,
      descricao: this.descricao,
      imagem: "",
      valor: this.valor
    });
    this.dialogRef.close();
  }
}