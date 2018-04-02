package br.com.pa.modelo.dominio;

import br.com.pa.enums.Acao;

public class Jogada {
	
	private Acao acao;
	
	private Carta carta;

	public Acao getAcao() {
		return acao;
	}

	public void setAcao(Acao acao) {
		this.acao = acao;
	}

	public Carta getCarta() {
		return carta;
	}

	public void setCarta(Carta carta) {
		this.carta = carta;
	}
}
