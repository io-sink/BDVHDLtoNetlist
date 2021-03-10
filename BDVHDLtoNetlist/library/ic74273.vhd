library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74273 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74273 is "74xx";
	attribute component_name of ic74273 is "74HC273";
	attribute footprint_name of ic74273 is "Package_DIP:DIP-20_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 10;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 20;
	attribute pin_type of VCC is "power_in";

	CLK : in std_logic;
	attribute pin_assign of CLK is 11;
	attribute pin_type of CLK is "input";
	CLRN : in std_logic;
	attribute pin_assign of CLRN is 1;
	attribute pin_type of CLRN is "input";

  D1 : in std_logic;
  attribute pin_assign of D1 is 3;
  attribute pin_type of D1 is "input";
  D2 : in std_logic;
  attribute pin_assign of D2 is 4;
  attribute pin_type of D2 is "input";
  D3 : in std_logic;
  attribute pin_assign of D3 is 7;
  attribute pin_type of D3 is "input";
  D4 : in std_logic;
  attribute pin_assign of D4 is 8;
  attribute pin_type of D4 is "input";
  D5 : in std_logic;
  attribute pin_assign of D5 is 13;
  attribute pin_type of D5 is "input";
  D6 : in std_logic;
  attribute pin_assign of D6 is 14;
  attribute pin_type of D6 is "input";
  D7 : in std_logic;
  attribute pin_assign of D7 is 17;
  attribute pin_type of D7 is "input";
  D8 : in std_logic;
  attribute pin_assign of D8 is 18;
  attribute pin_type of D8 is "input";
	
  Q1 : out std_logic;
  attribute pin_assign of Q1 is 2;
  attribute pin_type of Q1 is "output";
  Q2 : out std_logic;
  attribute pin_assign of Q2 is 5;
  attribute pin_type of Q2 is "output";
  Q3 : out std_logic;
  attribute pin_assign of Q3 is 6;
  attribute pin_type of Q3 is "output";
  Q4 : out std_logic;
  attribute pin_assign of Q4 is 9;
  attribute pin_type of Q4 is "output";
  Q5 : out std_logic;
  attribute pin_assign of Q5 is 12;
  attribute pin_type of Q5 is "output";
  Q6 : out std_logic;
  attribute pin_assign of Q6 is 15;
  attribute pin_type of Q6 is "output";
  Q7 : out std_logic;
  attribute pin_assign of Q7 is 16;
  attribute pin_type of Q7 is "output";
  Q8 : out std_logic;
  attribute pin_assign of Q8 is 19;
  attribute pin_type of Q8 is "output"
	);
	end ic74273;

architecture logic of ic74273 is 
  component comp74273
    port (
			CLK :  IN  STD_LOGIC;
			CLRN :  IN  STD_LOGIC;
			D1 :  IN  STD_LOGIC;
			D2 :  IN  STD_LOGIC;
			D3 :  IN  STD_LOGIC;
			D4 :  IN  STD_LOGIC;
			D5 :  IN  STD_LOGIC;
			D6 :  IN  STD_LOGIC;
			D7 :  IN  STD_LOGIC;
			D8 :  IN  STD_LOGIC;
			Q1 :  OUT  STD_LOGIC;
			Q2 :  OUT  STD_LOGIC;
			Q3 :  OUT  STD_LOGIC;
			Q4 :  OUT  STD_LOGIC;
			Q5 :  OUT  STD_LOGIC;
			Q6 :  OUT  STD_LOGIC;
			Q7 :  OUT  STD_LOGIC;
			Q8 :  OUT  STD_LOGIC
    );
  end component;
begin 

  inst : comp74273
    port map (
			CLK => CLK, 
			CLRN => CLRN, 
			D1 => D1, 
			D2 => D2, 
			D3 => D3, 
			D4 => D4, 
			D5 => D5, 
			D6 => D6, 
			D7 => D7, 
			D8 => D8, 
			Q1 => Q1, 
			Q2 => Q2, 
			Q3 => Q3, 
			Q4 => Q4, 
			Q5 => Q5, 
			Q6 => Q6, 
			Q7 => Q7, 
			Q8 => Q8
    );

end logic;