import React, {useState,useEffect} from 'react';
import './styles.css';

export default function Home(){
    return(
        <div className="home-container">
            <section className="form">
                <form>
                    <h1>Novo Lembrete</h1>
                    <div className="input-container">
                        <button className='visual-button'>Nome</button>
                        <input placeholder='Nome do lembrete'></input>
                    </div>

                    <div className="input-container">
                        <button className='visual-button'>Data</button>
                        <input type="text" 
                            placeholder='Data do lembrete (formato dd/mm/aaaa)'
                            required pattern="\d{2}/\d{2}/\d{4}"
                            ></input>
                    </div>
                    <button className='submit-button' type='submit'>Criar</button>
                </form>
            </section>
        </div>
    
    
    
        );
}