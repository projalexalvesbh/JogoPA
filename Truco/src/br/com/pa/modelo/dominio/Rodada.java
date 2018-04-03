package br.com.pa.modelo.dominio;

public class Rodada {
	
	Mao[] mao = new Mao[3];
	
	private int pontuacaoEquipe1;
	
	private int pontuacaoEquipe2;
	
	public Mao[] getMao() {
		return mao;
	}

	public void setMao(Mao[] mao) {
		this.mao = mao;
	}

	public int getPontuacaoEquipe(int equipe) {
		
		switch (equipe) {
		case 1:
			
			return pontuacaoEquipe1;

		default:
			return pontuacaoEquipe2;
		}
	}

	public void setPontuacaoEquipe(int equipe, int pontuacaoEquipe) {
		
		switch (equipe) {
		case 1:
			
			this.pontuacaoEquipe1 = pontuacaoEquipe;
		default:
			this.pontuacaoEquipe2 = pontuacaoEquipe;
		}
	}
	
	public int getPontosParaVencer(int equipe) {
		
		return 12 - getPontuacaoEquipe(equipe);
	}
}
