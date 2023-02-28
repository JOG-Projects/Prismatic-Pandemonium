import { Component, OnInit, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'

})
export class AppComponent implements OnInit{
  constructor(
    title: Title
  ) {
    title.setTitle('Prismatic Pandemonium')
  }
  ngOnInit(): void {
   
   
}
   public moveCard() {
    console.log("teste")
    var cards = document.querySelectorAll<HTMLElement>('.player-hand img');

    console.log("teste")
    for (var i = 0; i < cards.length; i++) {
      cards[i].style.position = 'absolute';
      cards[i].style.transform = "translateY(-300px) translateX(-300px)";
      cards[i].style.rotate = "360deg";
      
    }
    console.log(cards);
  }

    deck = [
    "../assets/blue0.png",
    "../assets/red12.png",
    "../assets/red5.png",
    "../assets/green0.png",
    "../assets/green1.png",
    "../assets/blue5.png",
    "../assets/yellow4.png",]

    @ViewChild("player_hand") player_hand : HTMLDivElement | null = null
}