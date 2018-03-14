package br.com.pa;

import br.com.pa.enums.Nipes;
import br.com.pa.modelo.dominio.Carta;
import br.com.pa.util.Utils;

public class Principal {

	public static void main(String[] args) {
		
		
		Carta[] baralho = new Carta[40];

		for (int i = 0; i < 4; i++) {
			
			for (int j = 0; j < 10; j++) {
				
				String nipe = Nipes.PAUS.getSigla();
				
				if (i == 1) {
					nipe = Nipes.COPAS.getSigla();
				}
				
				if (i == 2) {
					nipe = Nipes.ESPADA.getSigla();
				}
				
				if (i == 3) {
					nipe = Nipes.OUROS.getSigla();
				}
				
				baralho[(i * 10) + j] = new Carta(j + 1, nipe);
			}
		}
		

		Carta[] baralhoSorteado = Utils.sortearCartas(baralho, 12);
		
		
		for (int i = 0; i < 12; i++) {
			
			System.out.println("\nCarta: " + baralhoSorteado[i].getValorFace() + " - Peso: " + baralhoSorteado[i].getPeso());
		}
	}

}
