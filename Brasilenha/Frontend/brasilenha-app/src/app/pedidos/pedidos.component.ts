import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-pedidos',
  standalone: true,
  imports: [CommonModule, NavbarComponent],
  templateUrl: './pedidos.component.html',
  styleUrl: './pedidos.component.css'
})
export class PedidosComponent {
 titulo: string = "Pedidos";

 @Input()
  pedidosRestantes: string = "Sem Pedidos";

}
