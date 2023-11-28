import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-cards',
  standalone: true,
  imports: [CommonModule],
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
  
  dataBsTarget: string = '"data-bs-target=' + this.id + '"';
  ariaControls: string = '"aria-controls="' + this.id + '"';
}
