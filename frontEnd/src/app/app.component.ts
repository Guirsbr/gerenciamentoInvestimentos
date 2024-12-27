import { Component } from '@angular/core';
import { InvestimentoService } from './services/investimento.service';
import { Investimento } from './models/investimento.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  imports: [CommonModule, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontEnd';

  investimentos: Investimento[] = []

  constructor(private investimentoService: InvestimentoService){
    this.obterInvestimentosDoUsuario();
  }

  obterInvestimentosDoUsuario(){
    this.investimentoService.obterInvestimentos()
      .subscribe(investimentos => this.investimentos = investimentos)
  }
}
