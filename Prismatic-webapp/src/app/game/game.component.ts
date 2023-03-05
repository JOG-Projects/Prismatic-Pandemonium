import { Component, ViewChild } from '@angular/core';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent {

  deck = [
    "../assets/blue0.png",
    "../assets/red12.png",
    "../assets/red5.png",
    "../assets/green0.png",
    "../assets/green1.png",
    "../assets/blue5.png",
    "../assets/yellow4.png"
  ]

  public moveCard(ev: MouseEvent) {
    const cardsContainer = document.getElementById('player_hand')
    // const cards = Array.from(cardsContainer!.querySelectorAll<HTMLElement>('.card'))
    const cards = document.querySelectorAll<HTMLElement>('.card')

    cards.forEach(card => {
      card.addEventListener('click', () => {
      const rect = card.getBoundingClientRect();
      const cartaX = rect.left + rect.width / 2;
      const cartaY = rect.top + rect.height / 2;

      const distanciaX = 725 - cartaX;
      const distanciaY = 381 - cartaY;
      const distancia = Math.sqrt(distanciaX * distanciaX + distanciaY * distanciaY);

      card.style.rotate = "360deg"
      card.style.transition = 'all 0.3s ease-in-out' 
      //tentar aplicar aq msm items para centralizar as cartas logo dps de serem jogadas
      //dps fazer nick de cada jogador e intefarce ao lado das cartas
      card.style.transform = `translate(${distanciaX}px, ${distanciaY}px)`;
  })
})
    // let card = ev.target as HTMLElement
    // card.style.position = 'absolute'
    // card.style.transform = 'translateY(-377px) translateX(100px)'
    // card.style.rotate = "360deg"
  }
  @ViewChild("player_hand") player_hand: HTMLDivElement | null = null

}