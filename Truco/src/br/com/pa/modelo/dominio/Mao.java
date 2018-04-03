package br.com.pa.modelo.dominio;

import br.com.pa.enums.Acao;

public class Mao {
	
	public static final String STATUS_ABERTA = "ABERTA";
	public static final String STATUS_ENCERRADA = "ENCERRADA";
	
	private Jogador[] jogadores;
	
	private Carta[] cartas;

	private Carta parceiro;

	private Carta[] cartaAdversarios = new Carta[2];
	
	private int posicaoRodada;
	
	private Acao acaoAdversario;
	
	private String status;
	
	private int equipeVencedora;
	
	private Acao acaoMesa;
	
	public Jogador[] getJogadores() {
		return jogadores;
	}

	public void setJogadores(Jogador[] jogadores) {
		this.jogadores = jogadores;
	}
	
	public Carta[] getCartas() {
		return cartas;
	}

	public void setCartas(Carta[] cartas) {
		this.cartas = cartas;
	}

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

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public int getEquipeVencedora() {
		return equipeVencedora;
	}

	public void setEquipeVencedora(int equipeVencedora) {
		this.equipeVencedora = equipeVencedora;
	}

	public Acao getAcaoMesa() {
		return acaoMesa;
	}

	public void setAcaoMesa(Acao acaoMesa) {
		this.acaoMesa = acaoMesa;
	}
}
