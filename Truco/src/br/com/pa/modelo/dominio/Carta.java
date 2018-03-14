package br.com.pa.modelo.dominio;

import br.com.pa.enums.Nipes;

public class Carta {
	
    int valor;
    String nipe;
    
    public Carta(int valor, String nipe) {
		super();
		this.valor = valor;
		this.nipe = nipe;
	}

	public int getPeso(){
        
        if ((valor == 4 && !nipe.equalsIgnoreCase(Nipes.PAUS.getSigla())) || 
                valor == 5 || 
                valor == 6 || 
                (valor == 7 && (!nipe.equalsIgnoreCase(Nipes.OUROS.getSigla()) && !nipe.equalsIgnoreCase(Nipes.COPAS.getSigla()))) ||
                (valor >= 8 && valor <= 10)){
            return valor - 3;
        }
        
        if (valor == 2 || valor == 3){
            return valor + 7;
        }
        
        if (valor == 1){
            if(!nipe.equalsIgnoreCase(Nipes.ESPADA.getSigla())){
                return 8;
            }else{
                return 12;
            }  
        }
        
        if(valor == 4){
            return 14;
        }
        if(valor == 7){
            if(nipe.equalsIgnoreCase(Nipes.OUROS.getSigla())){
                return 11;
            }else{
                return 13;
            } 
        }
        return 0;
    }
	
	public String getValorFace() {
		
		String retorno = "";
		
		switch (valor) {
		case 1:
			retorno = "A " + Nipes.getNipe(nipe).name();
			break;
		case 8:
			retorno = "Q " + Nipes.getNipe(nipe).name();
			break;
			
		case 9:
			retorno = "J " + Nipes.getNipe(nipe).name();
			break;
			
		case 10:
			retorno = "K " + Nipes.getNipe(nipe).name();
			break;
			
		default:
			retorno = valor + " " + Nipes.getNipe(nipe).name();
			break;
		}
		
		return retorno + " - Peso: " + getPeso();
	}

	public int getValor() {
		return valor;
	}

	public String getNipe() {
		return nipe;
	}
}
