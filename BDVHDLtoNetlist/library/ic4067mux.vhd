library IEEE;
use IEEE.std_logic_1164.all; 

entity ic4067mux is 
port
	(
		attribute library_name : string;
		attribute component_name : string;
		attribute footprint_name : string;
		attribute const_assign : string;
		attribute pin_assign : integer;

		attribute library_name of ic4067mux is "4xxx";
		attribute component_name of ic4067mux is "4067";
		attribute footprint_name of ic4067mux is "Package_DIP:DIP-24_W15.24mm_Socket_LongPads";

		VSS : in std_logic;
		attribute const_assign of VSS is "GND";
		attribute pin_assign of VSS is 12;
		attribute pin_type of VSS is "power_in";
		VDD : in std_logic;
		attribute const_assign of VDD is "VCC";
		attribute pin_assign of VDD is 24;
		attribute pin_type of VDD is "power_in";

		INH : in std_logic;
		attribute const_assign of INH is "GND";
		attribute pin_assign of INH is 15;
		attribute pin_type of INH is "input";

		D0 : in std_logic;
		attribute pin_assign of D0 is 9;
		attribute pin_type of D0 is "input";
		D1 : in std_logic;
		attribute pin_assign of D1 is 8;
		attribute pin_type of D1 is "input";
		D2 : in std_logic;
		attribute pin_assign of D2 is 7;
		attribute pin_type of D2 is "input";
		D3 : in std_logic;
		attribute pin_assign of D3 is 6;
		attribute pin_type of D3 is "input";
		D4 : in std_logic;
		attribute pin_assign of D4 is 5;
		attribute pin_type of D4 is "input";
		D5 : in std_logic;
		attribute pin_assign of D5 is 4;
		attribute pin_type of D5 is "input";
		D6 : in std_logic;
		attribute pin_assign of D6 is 3;
		attribute pin_type of D6 is "input";
		D7 : in std_logic;
		attribute pin_assign of D7 is 2;
		attribute pin_type of D7 is "input";
		D8 : in std_logic;
		attribute pin_assign of D8 is 23;
		attribute pin_type of D8 is "input";
		D9 : in std_logic;
		attribute pin_assign of D9 is 22;
		attribute pin_type of D9 is "input";
		D10 : in std_logic;
		attribute pin_assign of D10 is 21;
		attribute pin_type of D10 is "input";
		D11 : in std_logic;
		attribute pin_assign of D11 is 20;
		attribute pin_type of D11 is "input";
		D12 : in std_logic;
		attribute pin_assign of D12 is 19;
		attribute pin_type of D12 is "input";
		D13 : in std_logic;
		attribute pin_assign of D13 is 18;
		attribute pin_type of D13 is "input";
		D14 : in std_logic;
		attribute pin_assign of D14 is 17;
		attribute pin_type of D14 is "input";
		D15 : in std_logic;
		attribute pin_assign of D15 is 16;
		attribute pin_type of D15 is "input";

		A : in std_logic;
		attribute pin_assign of A is 10;
		attribute pin_type of A is "input";
		B : in std_logic;
		attribute pin_assign of B is 11;
		attribute pin_type of B is "input";
		C : in std_logic;
		attribute pin_assign of C is 14;
		attribute pin_type of C is "input";
		D : in std_logic;
		attribute pin_assign of D is 13;
		attribute pin_type of D is "input";

		Y : out std_logic;
		attribute pin_assign of Y is 1;
		attribute pin_type of Y is "output"
	);
end ic4067mux;

architecture logic of ic4067mux is 
	component comp4067mux
		port (
			INH :  IN  STD_LOGIC;
			D0 :  IN  STD_LOGIC;
			D1 :  IN  STD_LOGIC;
			D2 :  IN  STD_LOGIC;
			D3 :  IN  STD_LOGIC;
			D4 :  IN  STD_LOGIC;
			D5 :  IN  STD_LOGIC;
			D6 :  IN  STD_LOGIC;
			D7 :  IN  STD_LOGIC;
			D8 :  IN  STD_LOGIC;
			D9 :  IN  STD_LOGIC;
			D10 :  IN  STD_LOGIC;
			D11 :  IN  STD_LOGIC;
			D12 :  IN  STD_LOGIC;
			D13 :  IN  STD_LOGIC;
			D14 :  IN  STD_LOGIC;
			D15 :  IN  STD_LOGIC;
			A :  IN  STD_LOGIC;
			B :  IN  STD_LOGIC;
			C :  IN  STD_LOGIC;
			D :  IN  STD_LOGIC;
			Y :  OUT  STD_LOGIC
		);
	end component;
begin 

  inst : comp4067mux
    port map (
			INH => INH, 
			D0 => D0, 
			D1 => D1, 
			D2 => D2, 
			D3 => D3, 
			D4 => D4, 
			D5 => D5, 
			D6 => D6, 
			D7 => D7, 
			D8 => D8, 
			D9 => D9, 
			D10 => D10, 
			D11 => D11, 
			D12 => D12, 
			D13 => D13, 
			D14 => D14, 
			D15 => D15, 
			A => A, 
			B => B, 
			C => C, 
			D => D, 
			Y => Y
    );

end logic;