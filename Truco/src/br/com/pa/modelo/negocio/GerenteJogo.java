package br.com.pa.modelo.negocio;

import java.util.Random;

import br.com.pa.enums.Acao;
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

					Jogada jogada = avaliarAcoesAdversario(rodada, mao, equipe);

					percentual = avaliarCartas(mao.getCartas());

					avaliarPosicaoRodada(mao.getPosicaoRodada());

					return retornarJogada(maosVencidas, percentual, mao.getCartas());

				} else if (Mao.STATUS_ENCERRADA.equalsIgnoreCase(mao.getStatus())
						&& mao.getEquipeVencedora() == equipe) {

					maosVencidas++;
				}
			}
		}

		return null;
	}

	private static Jogada avaliarAcoesAdversario(Rodada rodada, Mao mao, int equipe) {

		Jogada jogada = null;
		
		Random random = new Random();
		
		Acao aumentarAposta;
		
		if (Acao.TRUCAR.equals(mao.getAcaoAdversario())) {
			
			aumentarAposta = Acao.SEIS;
			
			if (Carta.getQualidade(mao.getCartas()) >= Carta.CARTA_OTIMA) {
				
				jogada = new Jogada(aumentarAposta, null);
			} else if (Carta.getQualidade(mao.getCartas()) >= Carta.CARTA_BOA) {

				jogada = new Jogada(( random.nextInt(10) > 4 ? Acao.ACEITAR : Acao.CORRER), null);
			}else {
				jogada = new Jogada(Acao.CORRER, null);
			}
			
		}if (Acao.SEIS.equals(mao.getAcaoAdversario())) {
			
			aumentarAposta = Acao.NOVE;
			
			if (Carta.getQualidade(mao.getCartas()) >= Carta.CARTA_OTIMA) {
				
				jogada = new Jogada(aumentarAposta, null);
			} else if (Carta.getQualidade(mao.getCartas()) >= Carta.CARTA_BOA) {

				jogada = new Jogada((random.nextInt(10) > 6 ? Acao.ACEITAR : Acao.CORRER), null);
			}else {
				
				jogada = new Jogada(Acao.CORRER, null);
			}
			
		}if (Acao.NOVE.equals(mao.getAcaoAdversario())) {
			
			aumentarAposta = Acao.DOZE;
			
			if (Carta.getQualidade(mao.getCartas()) >= Carta.CARTA_OTIMA) {
				
				jogada = new Jogada(aumentarAposta, null);
			} else if (Carta.getQualidade(mao.getCartas()) >= Carta.CARTA_BOA) {

				jogada = new Jogada((random.nextInt(10) > 6 ? Acao.ACEITAR : Acao.CORRER), null);
			}else {
				
				jogada = new Jogada(Acao.CORRER, null);
			}
		}
		
		if(rodada.getPontosParaVencer(equipe) < mao.getValor())

		return jogada;
	}

	private static Jogada retornarJogada(int maosVencidas, int multiplicador, Carta[] cartas) {

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
