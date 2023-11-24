import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-totem',
  standalone: true,
  imports: [CommonModule, NavbarComponent],
  templateUrl: './totem.component.html',
  styleUrl: './totem.component.css'
})
export class TotemComponent {

}
