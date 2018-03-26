package br.com.pa.modelo.dominio;

import br.com.pa.enums.Acao;

public class Rodada {

	private Carta parceiro;

	private Carta[] cartaAdversarios = new Carta[2];
	
	private int posicaoRodada;
	
	private Acao acaoAdversario;

	
	
	
	public Carta getParceiro() {
		return parceiro;
	}

	public void setParceiro(Carta parceiro) {
		this.parceiro = parceiro;
	}

	public Carta[] getCartaAdversarios() {
		return cartaAdversarios;
	}

	public void setCartaAdversarios(Carta[] cartaAdversarios) {
		this.cartaAdversarios = cartaAdversarios;
	}

	public int getPosicaoRodada() {
		return posicaoRodada;
	}

	public void setPosicaoRodada(int posicaoRodada) {
		this.posicaoRodada = posicaoRodada;
	}

	public Acao getAcaoAdversario() {
		return acaoAdversario;
	}

	public void setAcaoAdversario(Acao acaoAdversario) {
		this.acaoAdversario = acaoAdversario;
	}
}
