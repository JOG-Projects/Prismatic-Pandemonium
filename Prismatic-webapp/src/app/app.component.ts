import { Component, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(title: Title) {
    title.setTitle('Prismatic Pandemonium')
  }

  public moveCard(ev: MouseEvent) {
    let card = ev.target as HTMLElement
    card.style.position = 'absolute'
    card.style.transform = "translateY(-300px) translateX(-300px)"
    card.style.rotate = "360deg"
  }

  deck = [
    "../assets/blue0.png",
    "../assets/red12.png",
    "../assets/red5.png",
    "../assets/green0.png",
    "../assets/green1.png",
    "../assets/blue5.png",
    "../assets/yellow4.png"
  ]

  @ViewChild("player_hand") player_hand: HTMLDivElement | null = null
}