package br.com.pa.modelo.dominio;

public class Jogador {
	
	public static String AGENTE_HUMANO = "JOGADOR";
	public static String AGENTE_COMPUTADOR = "COMPUTADOR";
	
	public static int EQUIPE1 = 1;
	public static int EQUIPE2 = 2;
	
	private String tipoAgente;
	
	private Carta[] jogo;
	
	private String equipe;

	public String getTipoAgente() {
		return tipoAgente;
	}

	public void setTipoAgente(String tipoAgente) {
		this.tipoAgente = tipoAgente;
	}

	public Carta[] getJogo() {
		return jogo;
	}

	public void setJogo(Carta[] jogo) {
		this.jogo = jogo;
	}

	public String getEquipe() {
		return equipe;
	}

	public void setEquipe(String equipe) {
		this.equipe = equipe;
	}
	
	
}
