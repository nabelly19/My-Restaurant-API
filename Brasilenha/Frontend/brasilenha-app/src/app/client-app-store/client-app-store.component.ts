import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';
import { CardsComponent } from '../cards/cards.component';

@Component({
  selector: 'app-client-app-store',
  standalone: true,
  imports: [CommonModule, NavbarComponent, CardsComponent],
  templateUrl: './client-app-store.component.html',
  styleUrl: './client-app-store.component.css'
})
export class ClientAppStoreComponent {

}
