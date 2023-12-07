import { Component, Input, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';


@Component({
  selector: 'app-cards',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule, FormsModule, MatInputModule ],
  templateUrl: './cards.component.html',
  styleUrl: './cards.component.css'
})
export class CardsComponent {
  @Input()
  imagem_card: string = "";
  @Input()
  id: string = "";
  @Input()
  content2: string = "";

  @Input()
  css: string = "";

  @Input()
  Cupom: string = "Infelizmente não há cupons para este prato :(";

  @Input()
  descricao: string = "KKKK"

  @Input()
  valor: string = "zero"

  dataBsTarget: string = '"data-bs-target=' + this.id + '"';
  ariaControls: string = '"aria-controls="' + this.id + '"';
  
}
