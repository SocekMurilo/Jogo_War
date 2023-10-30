using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Linq;

Random rand = new Random();
int N = 10_000;
 
int[] defensiveVetor = new int[3];
int[] atackVetor = new int[3];

int atackVictory = 0;
int defensiveVictory = 0;

Jogo_War();

int roll()
=> rand.Next(6) + 1; 
void Jogo_War()
{
    int count = 0;
    for (int i = 0; i < N; i++)
    {
        int atack = 2;
        int defensive = 1;

        while (atack > 1 && defensive > 0){
            int rodarAtack = atack > 4 ? 3 : atack - 1;
            int rodarDefensive = defensive > 3 ? 3 : defensive;

            for (int j = 0; j < rodarAtack; j++)
                atackVetor[j] = roll();
            Array.Sort(atackVetor);
            Array.Reverse(atackVetor);

            for (int j = 0; j < rodarDefensive; j++)
                defensiveVetor[j] = roll();            
            Array.Sort(defensiveVetor);
            Array.Reverse(defensiveVetor);
        
            int figths = int.Min(rodarAtack, rodarDefensive);

            for (int j = 0; j < figths; j++)
            {
                if (atackVetor[j] > defensiveVetor[j])
                    defensive--;
                else
                    atack--;
            }
        }
        if (atack <= 1)
            defensiveVictory++;
        if (defensive <= 0)
            atackVictory++;
        count++;


    }

        float mediaAtack = (float)atackVictory/count * 100;
        float mediaDefensive = (float)defensiveVictory/count * 100;
        Console.WriteLine(mediaAtack);
        Console.WriteLine(mediaDefensive);
        Console.WriteLine(count);
}

// Console.WriteLine("[{0}]", string.Join(", ", atackVetor));
// Console.WriteLine("[{0}]", string.Join(", ", defensiveVetor));
 
