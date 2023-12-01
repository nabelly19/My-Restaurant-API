import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogRef} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ClientServiceService } from '../client-service.service';
import { NavbarComponent } from '../navbar/navbar.component';
import { CardsComponent } from '../cards/cards.component';

@Component({
  selector: 'app-novo-prato-dialog',
  standalone: true,
  imports: [CommonModule, NavbarComponent, CardsComponent],
  templateUrl: './novo-prato-dialog.component.html',
  styleUrl: './cardapio.component.css'
})
export class NovoPratoDialog
{
  constructor(public dialogRef: MatDialogRef<NovoPratoDialog>) {}

  imagemUrl: string = ""
  nomeProduto: string = ""
  cupomProduto: string = ""
  descricaoProduto: string = ""
}

@Component({
  selector: 'app-cardapio',
  standalone: true,
  imports: [CommonModule, NavbarComponent, CardsComponent, FormsModule],
  templateUrl: './cardapio.component.html',
  styleUrl: './cardapio.component.css'
})


export class CardapioComponent {
  
  constructor (public dialog: MatDialog) { }

  @Input()
  nomeDoCard: string = ""

  option1()
  {
    this.dialog.open(NovoPratoDialog);
  }
}
