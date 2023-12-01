import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  @Input()
  tituloDaNav: string = "Outras opções";

  @Input()
  Content1: string = "op1";

  @Input()
  Content2: string = "op1";

  @Input()
  Content3: string = "op3";

  @Input()
  funcao: any = () => { };
}
