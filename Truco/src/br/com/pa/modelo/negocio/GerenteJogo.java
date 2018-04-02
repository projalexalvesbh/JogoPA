package br.com.pa.modelo.negocio;

import br.com.pa.modelo.dominio.Carta;
import br.com.pa.modelo.dominio.Jogada;
import br.com.pa.modelo.dominio.Mao;
import br.com.pa.modelo.dominio.Rodada;

public class GerenteJogo {

	public static Jogada avaliarMao(Rodada rodada, int equipe) {

		int percentual = 0;

		int maosVencidas = 0;

		for (Mao mao : rodada.getMao()) {

			if (mao != null) {
				if (Mao.STATUS_ABERTA.equalsIgnoreCase(mao.getStatus())) {

					percentual = avaliarCartas(mao.getCartas());

					avaliarPosicaoRodada(mao.getPosicaoRodada());
				} else if (Mao.STATUS_ENCERRADA.equalsIgnoreCase(mao.getStatus())
						&& mao.getEquipeVencedora() == equipe) {

					maosVencidas++;
				}
			}
		}

		return retornarJogada(percentual, mao.getCartas());
	}

	private static Jogada retornarJogada(int multiplicador, Carta[] cartas) {

		return null;
	}

	private static int avaliarCartas(Carta[] cartas) {

		if (Carta.ZAP.isContemEm(cartas) && Carta.SETE_COPAS.isContemEm(cartas)) {
			return 100;
		} else if (Carta.SETE_COPAS.isContemEm(cartas) && Carta.ESPADILHA.isContemEm(cartas)
				&& Carta.SETE_OUROS.isContemEm(cartas)) {
			return 100;
		} else {

			switch (Carta.getQualidade(cartas)) {
			case Carta.CARTA_RUIM:
				return 20;

			case Carta.CARTA_MEDIO:
				return 40;

			case Carta.CARTA_BOA:
				return 60;

			case Carta.CARTA_OTIMA:
			default:
				return 80;
			}
		}

		// return 0;
	}

	private static double avaliarPosicaoRodada(int posicao) {

		switch (posicao) {
		case 1:

			break;

		default:
			break;
		}

		return 1;
	}

}
