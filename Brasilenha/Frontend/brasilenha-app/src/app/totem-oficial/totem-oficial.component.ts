import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardsComponent } from '../cards/cards.component';

@Component({
  selector: 'app-totem-oficial',
  standalone: true,
  imports: [CommonModule, CardsComponent ],
  templateUrl: './totem-oficial.component.html',
  styleUrl: './totem-oficial.component.css'
})
export class TotemOficialComponent {

}
