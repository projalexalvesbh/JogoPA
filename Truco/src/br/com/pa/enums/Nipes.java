package br.com.pa.enums;

public enum Nipes {
	
	PAUS("P"), COPAS("C"), OUROS("O"), ESPADA("E");
	
	private String sigla;
	
	private Nipes(String sigla) {
		this.sigla = sigla;
	}

	public String getSigla() {
		return sigla;
	}

	public void setSigla(String sigla) {
		this.sigla = sigla;
	}
	
	public static Nipes getNipe(String sigla) {
		switch (sigla) {
		case "P":
			return Nipes.PAUS;
		case "C":
			return Nipes.COPAS;
		case "O":
			return Nipes.OUROS;
		default:
			return Nipes.ESPADA;
		}
	}
}
