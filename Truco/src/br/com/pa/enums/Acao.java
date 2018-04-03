package br.com.pa.enums;

public enum Acao {
	JOGAR, TRUCAR, ACEITAR, SEIS, NOVE, DOZE, CORRER;

	
	public int getValorAposta() {
		
		switch (this) {
		case TRUCAR:
			return 4;

		case SEIS:
			return 8;

		case NOVE:
			return 10;

		case DOZE:
			return 12;

		default:
			return 2;
		}
	}
	
	public Acao aumentarAposta() {
		switch (this) {
		case TRUCAR:
			return Acao.SEIS;

		case SEIS:
			return Acao.NOVE;

		case NOVE:
			return Acao.DOZE;
			
		case ACEITAR:
		case CORRER:
			return Acao.ACEITAR;

		default:
			return Acao.TRUCAR;
		}
	}
}
