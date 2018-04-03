package br.com.pa.modelo.negocio;

import java.util.Random;

import br.com.pa.enums.Acao;
import br.com.pa.modelo.dominio.Carta;
import br.com.pa.modelo.dominio.Jogada;
import br.com.pa.modelo.dominio.Jogador;
import br.com.pa.modelo.dominio.Mao;
import br.com.pa.modelo.dominio.Rodada;

public class GerenteJogo {

	public static Jogada avaliarMao(Rodada rodada, int jogador) {
		
		int percentual = 0;

		int maosVencidas = 0;
		
		Jogada jogada = null;

		for (Mao mao : rodada.getMao()) {

			if (mao != null) {
				
				int equipe =  mao.getJogadores()[jogador].getEquipe();
				
				Carta[] cartasJogador = mao.getJogadores()[jogador].getJogo();
				
				if (Mao.STATUS_ABERTA.equalsIgnoreCase(mao.getStatus())) {
					
					jogada = avaliarJogada(rodada, mao, jogador);

					return retornarJogada(maosVencidas, percentual, cartasJogador);

				} else if (Mao.STATUS_ENCERRADA.equalsIgnoreCase(mao.getStatus())
						&& mao.getEquipeVencedora() == equipe) {

					maosVencidas++;
				}
			}
		}

		return null;
	}

	private static Jogada avaliarJogada(Rodada rodada, Mao mao, int jogador) {

		Jogada jogada = null;
		
		int equipe = mao.getJogadores()[jogador].getEquipe();
		
		Carta[] cartasJogador = mao.getJogadores()[jogador].getJogo();

		Random random = new Random();

		float indiceAceitacao = getIndiceAceitar(rodada, equipe);

		Acao aumentarAposta;

		if (Acao.TRUCAR.equals(mao.getAcaoAdversario())) {

			aumentarAposta = Acao.SEIS;

			if (Carta.getQualidade(cartasJogador) >= Carta.CARTA_OTIMA) {

				jogada = new Jogada(aumentarAposta, null);
			} else if (Carta.getQualidade(cartasJogador) >= Carta.CARTA_BOA) {

				jogada = new Jogada((random.nextInt(100) > (40 * indiceAceitacao) ? Acao.ACEITAR : Acao.CORRER), null);
			} else {
				jogada = new Jogada(Acao.CORRER, null);
			}

		}
		if (Acao.SEIS.equals(mao.getAcaoAdversario())) {

			aumentarAposta = Acao.NOVE;

			if (Carta.getQualidade(cartasJogador) >= Carta.CARTA_OTIMA) {

				jogada = new Jogada(aumentarAposta, null);
			} else if (Carta.getQualidade(cartasJogador) >= Carta.CARTA_BOA) {

				jogada = new Jogada((random.nextInt(100) > (60 * indiceAceitacao) ? Acao.ACEITAR : Acao.CORRER), null);
			} else {

				jogada = new Jogada(Acao.CORRER, null);
			}

		}
		if (Acao.NOVE.equals(mao.getAcaoAdversario())) {

			aumentarAposta = Acao.DOZE;

			if (Carta.getQualidade(cartasJogador) >= Carta.CARTA_OTIMA) {

				jogada = new Jogada(aumentarAposta, null);
			} else if (Carta.getQualidade(cartasJogador) >= Carta.CARTA_BOA) {

				jogada = new Jogada((random.nextInt(100) > (50 * indiceAceitacao) ? Acao.ACEITAR : Acao.CORRER), null);
			} else {

				jogada = new Jogada(Acao.CORRER, null);
			}
		}

		if (Acao.DOZE.equals(mao.getAcaoAdversario())) {

			aumentarAposta = Acao.ACEITAR;

			if (Carta.getQualidade(cartasJogador) >= Carta.CARTA_OTIMA) {

				jogada = new Jogada(aumentarAposta, null);
			} else if (Carta.getQualidade(cartasJogador) >= Carta.CARTA_BOA) {

				jogada = new Jogada((random.nextInt(100) > (30 * indiceAceitacao) ? Acao.ACEITAR : Acao.CORRER), null);
			} else {

				jogada = new Jogada(Acao.CORRER, null);
			}
		}

		if (jogada != null && mao.getAcaoAdversario().getValorAposta() == jogada.getAcao().getValorAposta()
				&& rodada.getPontosParaVencer(equipe) < mao.getAcaoAdversario().getValorAposta()
				&& (jogada.getAcao().equals(Acao.ACEITAR) && !mao.getAcaoMesa().equals(Acao.DOZE))) {

			jogada.setAcao(jogada.getAcao().aumentarAposta());
		}

		if (jogada != null) {
			return jogada;
		}
		
		if (Acao.JOGAR.equals(mao.getAcaoMesa())) {
			jogada = avaliarJogadaSimples(rodada, mao, jogador);
		}

		return jogada;
	}

	private static Jogada avaliarJogadaSimples(Rodada rodada, Mao mao, int jogador) {
		
		Carta cartaJogar = avaliarCartaJogar(jogador, rodada, mao);
		
		
		

		return null;
	}

	private static Carta avaliarCartaJogar(int jogadorCodigo, Rodada rodada, Mao maoCorrente) {
		
		Jogador jogador = maoCorrente.getJogadores()[jogadorCodigo];
		
		int indiceMaoCorrente = getIndiceMaoCorrente(rodada);
		
		int vitorias = getVitoriasEquipe(rodada, jogador.getEquipe());
		
		int posicaoJogador = getPosicaoJogador(maoCorrente);
		
		Carta cartaRetorno = null;
		
		switch (vitorias) {
		case 0:
			
			switch (indiceMaoCorrente) {
			case 0:
				
				switch (posicaoJogador) {
				case 0:
					cartaRetorno = Carta.getMenorCarta(jogador.getJogo());
					break;

				case 1:
					cartaRetorno = Carta.getMenorCarta(jogador.getJogo());
					break;

				case 2:
					cartaRetorno = Carta.getMenorCarta(jogador.getJogo());
					break;

				case 3:
					cartaRetorno = Carta.getMenorCarta(jogador.getJogo());
					break;

				default:
					break;
				}
				
				break;

			default:
				break;
			}
			
			break;

		default:
			break;
		}
		
		
		return cartaRetorno;
	}

	private static float getIndiceAceitar(Rodada rodada, int equipe) {

		int vitorias = getVitoriasEquipe(rodada, equipe);

		float retorno = 1f;
		
		if (getMaoCorrente(rodada, equipe) == 1){
			if (vitorias != 1) {

				retorno = 0.3f;
			}
		}
		return retorno;
	}

	private static int getVitoriasEquipe(Rodada rodada, int equipe) {
		int numeroVitorias = 0;
		for (Mao mao : rodada.getMao()) {
			if (mao != null && mao.getEquipeVencedora() == equipe) {

				numeroVitorias++;
			}
		}
		return numeroVitorias;
	}

	private static int getIndiceMaoCorrente(Rodada rodada) {

		int retorno = 0;
		for (Mao mao : rodada.getMao()) {
			if (mao != null) {

				retorno++;
			}
		}
		return retorno;
	}
	
	private static int getPosicaoJogador(Mao mao) {

		int retorno = 0;
		for (int i = 0; i< mao.getCartas().length; i++) {
			if (mao.getCartas()[i] == null) {

				return retorno;
			}
			
			retorno++;
		}
		return retorno;
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
