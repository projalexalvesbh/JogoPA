package br.com.pa.util;

import java.util.HashMap;
import java.util.Map;
import java.util.Random;

import br.com.pa.modelo.dominio.Carta;

public class Utils {
	
	public static Carta[] sortearCartas(Carta[] baralho, int quantidade) {
		
		Map<Integer, Integer> sorteados = new HashMap<>();
		
		Random r = new Random();
		
		Carta retorno[] = new Carta[quantidade];
		
		int i = 0;
		
		int posicaoCarta;
		
		while (i < quantidade) {
			
			posicaoCarta = r.nextInt(baralho.length);
			
			if(!sorteados.containsKey(posicaoCarta)) {
				
				retorno[i] = baralho[posicaoCarta];
				i++;
				sorteados.put(posicaoCarta, posicaoCarta);
			}
		}
		
		return retorno;
	}

}
