library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74175 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74175 is "74xx";
	attribute component_name of ic74175 is "74HC175";
	attribute footprint_name of ic74175 is "Package_DIP:DIP-16_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 8;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 16;
	attribute pin_type of VCC is "power_in";

	CLK : in std_logic;
	attribute pin_assign of CLK is 9;
	attribute pin_type of CLK is "input";
	CLRN : in std_logic;
	attribute pin_assign of CLRN is 1;
	attribute pin_type of CLRN is "input";
	
	D1 : in std_logic;
	attribute pin_assign of D1 is 4;
	attribute pin_type of D1 is "input";
	D2 : in std_logic;
	attribute pin_assign of D2 is 5;
	attribute pin_type of D2 is "input";
	D3 : in std_logic;
	attribute pin_assign of D3 is 12;
	attribute pin_type of D3 is "input";
	D4 : in std_logic;
	attribute pin_assign of D4 is 13;
	attribute pin_type of D4 is "input";

  Q1 : out std_logic;
  attribute pin_assign of Q1 is 2;
  attribute pin_type of Q1 is "output";
  Q2 : out std_logic;
  attribute pin_assign of Q2 is 7;
  attribute pin_type of Q2 is "output";
  Q3 : out std_logic;
  attribute pin_assign of Q3 is 10;
  attribute pin_type of Q3 is "output";
  Q4 : out std_logic;
  attribute pin_assign of Q4 is 15;
  attribute pin_type of Q4 is "output";

  QN1 : out std_logic;
  attribute pin_assign of QN1 is 3;
  attribute pin_type of QN1 is "output";
  QN2 : out std_logic;
  attribute pin_assign of QN2 is 6;
  attribute pin_type of QN2 is "output";
  QN3 : out std_logic;
  attribute pin_assign of QN3 is 11;
  attribute pin_type of QN3 is "output";
  QN4 : out std_logic;
  attribute pin_assign of QN4 is 14;
  attribute pin_type of QN4 is "output"
	);
	end ic74175;

architecture logic of ic74175 is 
  component comp74175
    port (
			CLK :  IN  STD_LOGIC;
			CLRN :  IN  STD_LOGIC;
			D1 :  IN  STD_LOGIC;
			D2 :  IN  STD_LOGIC;
			D3 :  IN  STD_LOGIC;
			D4 :  IN  STD_LOGIC;
			Q1 :  OUT  STD_LOGIC;
			Q2 :  OUT  STD_LOGIC;
			Q3 :  OUT  STD_LOGIC;
			Q4 :  OUT  STD_LOGIC;
			QN1 :  OUT  STD_LOGIC;
			QN2 :  OUT  STD_LOGIC;
			QN3 :  OUT  STD_LOGIC;
			QN4 :  OUT  STD_LOGIC
    );
  end component;
begin 

  inst : comp74175
    port map (
			CLK => CLK,
			CLRN => CLRN, 
			D1 => D1, 
			D2 => D2, 
			D3 => D3, 
			D4 => D4, 
			Q1 => Q1, 
			Q2 => Q2, 
			Q3 => Q3, 
			Q4 => Q4, 
			QN1 => QN1, 
			QN2 => QN2, 
			QN3 => QN3, 
			QN4 => QN4
    );

end logic;