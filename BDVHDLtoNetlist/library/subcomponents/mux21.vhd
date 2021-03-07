library IEEE;
use IEEE.std_logic_1164.all; 

entity mux21 is 
port
	(S : in std_logic;
		A : in std_logic;
		B : in std_logic;
		Y : out std_logic);
end mux21;

architecture logic of mux21 is 
begin

	Y <= A when S = '0' else B;
	
end logic;