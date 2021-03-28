library IEEE;
use IEEE.std_logic_1164.all; 

entity ic7474 is 
port
	(
		attribute library_name : string;
		attribute component_name : string;
		attribute footprint_name : string;
		attribute const_assign : string;
		attribute pin_assign : integer;

		attribute library_name of ic7474 is "74xx";
		attribute component_name of ic7474 is "74HC74";
		attribute footprint_name of ic7474 is "Package_DIP:DIP-14_W7.62mm_Socket_LongPads";

		GND : in std_logic;
		attribute const_assign of GND is "GND";
		attribute pin_assign of GND is 7;
		attribute pin_type of GND is "power_in";
		VCC : in std_logic;
		attribute const_assign of VCC is "VCC";
		attribute pin_assign of VCC is 14;
		attribute pin_type of VCC is "power_in";
	
		CLRN1 : in std_logic;
		attribute pin_assign of CLRN1 is 1;
		attribute pin_type of CLRN1 is "input";
		D1 : in std_logic;
		attribute pin_assign of D1 is 2;
		attribute pin_type of D1 is "input";
		CLK1 : in std_logic;
		attribute pin_assign of CLK1 is 3;
		attribute pin_type of CLK1 is "input";
		PRN1 : in std_logic;
		attribute pin_assign of PRN1 is 4;
		attribute pin_type of PRN1 is "input";
		Q1 : out std_logic;
		attribute pin_assign of Q1 is 5;
		attribute pin_type of Q1 is "output";
		QN1 : out std_logic;
		attribute pin_assign of QN1 is 6;
		attribute pin_type of QN1 is "output";
	
		CLRN2 : in std_logic;
		attribute pin_assign of CLRN2 is 13;
		attribute pin_type of CLRN2 is "input";
		D2 : in std_logic;
		attribute pin_assign of D2 is 12;
		attribute pin_type of D2 is "input";
		CLK2 : in std_logic;
		attribute pin_assign of CLK2 is 11;
		attribute pin_type of CLK2 is "input";
		PRN2 : in std_logic;
		attribute pin_assign of PRN2 is 10;
		attribute pin_type of PRN2 is "input";
		Q2 : out std_logic;
		attribute pin_assign of Q2 is 9;
		attribute pin_type of Q2 is "output";
		QN2 : out std_logic;
		attribute pin_assign of QN2 is 8;
		attribute pin_type of QN2 is "output"
	);
end ic7474;

architecture logic of ic7474 is 

	component dff74
		port(
		PRN :  IN  STD_LOGIC;
		D :  IN  STD_LOGIC;
		CLK :  IN  STD_LOGIC;
		CLRN :  IN  STD_LOGIC;
		Q :  OUT  STD_LOGIC;
		QN :  OUT  STD_LOGIC);
	end component;

begin 

	dff1 : dff74
	port MAP(
			PRN => PRN1,
			D => D1,
			CLK => CLK1,
			CLRN => CLRN1, 
			Q => Q1, 
			QN => QN1);

	dff2 : dff74
	port MAP(
			PRN => PRN2,
			D => D2,
			CLK => CLK2,
			CLRN => CLRN2, 
			Q => Q2, 
			QN => QN2);

end logic;