package br.com.pa.modelo.dominio;

import java.util.Arrays;
import java.util.List;

import br.com.pa.enums.Nipes;

public class Carta {

	public static final Carta ZAP = new Carta(4, Nipes.PAUS.name());
	public static final Carta SETE_COPAS = new Carta(7, Nipes.COPAS.name());
	public static final Carta ESPADILHA = new Carta(1, Nipes.ESPADA.name());
	public static final Carta SETE_OUROS = new Carta(7, Nipes.OUROS.name());

	public static final int CARTA_RUIM = 0;
	public static final int CARTA_MEDIO = 1;
	public static final int CARTA_BOA = 2;
	public static final int CARTA_OTIMA = 3;

	public static final int VALOR_AS = 1;
	public static final int VALOR_REI = 10;
	public static final int VALOR_VALETE = 9;
	public static final int VALOR_DAMA = 8;

	int valor;
	String nipe;
	int equipe;
	boolean encobrirCarta = false;
	boolean disponivel = true;

	public Carta(int valor, String nipe) {
		super();
		this.valor = valor;
		this.nipe = nipe;
	}

	public int getPeso() {

		if ((valor == 4 && !nipe.equalsIgnoreCase(Nipes.PAUS.getSigla())) || valor == 5 || valor == 6 || (valor == 7
				&& (!nipe.equalsIgnoreCase(Nipes.OUROS.getSigla()) && !nipe.equalsIgnoreCase(Nipes.COPAS.getSigla())))
				|| (valor >= VALOR_DAMA && valor <= VALOR_REI)) {
			return valor - 3;
		}

		if (valor == 2 || valor == 3) {
			return valor + 7;
		}

		if (valor == 1) {
			if (!nipe.equalsIgnoreCase(Nipes.ESPADA.getSigla())) {
				return 8;
			} else {
				return 12;
			}
		}

		if (valor == 4) {
			return 14;
		}
		if (valor == 7) {
			if (nipe.equalsIgnoreCase(Nipes.OUROS.getSigla())) {
				return 11;
			} else {
				return 13;
			}
		}
		return 0;
	}

	public String getValorFace() {

		String retorno = "";

		switch (valor) {
		case 1:
			retorno = "A " + Nipes.getNipe(nipe).name();
			break;
		case 8:
			retorno = "Q " + Nipes.getNipe(nipe).name();
			break;

		case 9:
			retorno = "J " + Nipes.getNipe(nipe).name();
			break;

		case 10:
			retorno = "K " + Nipes.getNipe(nipe).name();
			break;

		default:
			retorno = valor + " " + Nipes.getNipe(nipe).name();
			break;
		}

		return retorno;
	}

	public int contemEm(Carta[] cartas) {

		List<Carta> cartasAux = Arrays.asList(cartas);

		int retorno = -1;

		for (int i = 0; i < cartasAux.size(); i++) {

			if (this.valor == cartasAux.get(i).getValor()
					&& this.getNipe().equalsIgnoreCase(cartasAux.get(i).getNipe())) {
				retorno = i;
			}
		}

		return retorno;
	}

	public boolean isContemEm(Carta[] cartas) {

		return contemEm(cartas) >= 0;
	}

	public static int getQualidade(int peso) {

		if (peso <= 7) {
			return CARTA_RUIM;
		} else if (peso <= 10) {
			return CARTA_MEDIO;
		} else if (peso <= 12) {
			return CARTA_BOA;
		} else {
			return CARTA_OTIMA;
		}
	}

	public static int getQualidade(Carta[] cartas) {

		int peso = 0;

		float soma = 0;
		for (Carta carta : cartas) {
			soma += carta.getPeso();
		}

		peso = Math.round(soma / cartas.length);

		return getQualidade(peso);
	}

	public static Carta getMaiorCarta(Carta[] carta) {

		Carta cartaRetorno = carta[0];

		for (Carta cartaPesq : carta) {

			if (cartaPesq.isDisponivel() && cartaPesq.getValor() > cartaRetorno.getValor()) {

				cartaRetorno = cartaPesq;
			}
		}

		return cartaRetorno;
	}

	public static Carta getMenorCarta(Carta[] carta) {

		Carta cartaRetorno = carta[0];

		for (Carta cartaPesq : carta) {

			if (cartaPesq.isDisponivel() && cartaPesq.getValor() < cartaRetorno.getValor()) {

				cartaRetorno = cartaPesq;
			}
		}

		return cartaRetorno;
	}
	
	
	public static Carta matarCarta(Carta[] cartaMesa, Carta[] cartasJogador, int equipe, int indiceMaoCorrente) {

		Carta cartaAdversario = getMaiorCarta(cartaMesa);
		
		if(cartaAdversario.getEquipe() != equipe) {
			return matarCarta(cartaAdversario, cartasJogador);
		}
	
		Carta cartaRetorno = getMenorCarta(cartasJogador); 
		
		if(indiceMaoCorrente > 0) {
			cartaRetorno.setEncobrirCarta(true);
		}
		
		return cartaRetorno;
	}
	
	private static Carta matarCarta(Carta cartaMesa, Carta[] cartasJogador) {
		
		Carta cartaRetorno = null;
		
		for (Carta carta : cartasJogador) {
			
			if(cartaRetorno == null) {
				if (carta.getValor() >= cartaMesa.getValor()) {
					cartaRetorno = carta;
				}
			}else{
				if (carta.getValor() >= cartaMesa.getValor() && carta.getValor() < cartaRetorno.getValor()) {
					cartaRetorno = carta;
				}
			}
		}

		if(cartaRetorno == null) {
			return getMenorCarta(cartasJogador);
		}
		
		return null;
	}

	public int getValor() {
		return valor;
	}

	public String getNipe() {
		return nipe;
	}

	public boolean isDisponivel() {
		return disponivel;
	}

	public void setDisponivel(boolean disponivel) {
		this.disponivel = disponivel;
	}

	public int getEquipe() {
		return equipe;
	}

	public void setEquipe(int equipe) {
		this.equipe = equipe;
	}

	public boolean isEncobrirCarta() {
		return encobrirCarta;
	}

	public void setEncobrirCarta(boolean encobrirCarta) {
		this.encobrirCarta = encobrirCarta;
	}
}
