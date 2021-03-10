library IEEE;
use IEEE.std_logic_1164.all; 

entity ic74138 is 
port (
	attribute library_name : string;
	attribute component_name : string;
	attribute footprint_name : string;
	attribute const_assign : string;
	attribute pin_assign : integer;

	attribute library_name of ic74138 is "74xx";
	attribute component_name of ic74138 is "74HC138";
	attribute footprint_name of ic74138 is "Package_DIP:DIP-16_W7.62mm_Socket_LongPads";

	GND : in std_logic;
	attribute const_assign of GND is "GND";
	attribute pin_assign of GND is 8;
	attribute pin_type of GND is "power_in";
	VCC : in std_logic;
	attribute const_assign of VCC is "VCC";
	attribute pin_assign of VCC is 16;
	attribute pin_type of VCC is "power_in";

	A : in std_logic;
	attribute pin_assign of A is 1;
	attribute pin_type of A is "input";
	B : in std_logic;
	attribute pin_assign of B is 2;
	attribute pin_type of B is "input";
	C : in std_logic;
	attribute pin_assign of C is 3;
	attribute pin_type of C is "input";

  G1 : in std_logic;
  attribute pin_assign of G1 is 6;
  attribute pin_type of G1 is "input";
  G2AN : in std_logic;
  attribute pin_assign of G2AN is 4;
  attribute pin_type of G2AN is "input";
  G2BN : in std_logic;
  attribute pin_assign of G2BN is 5;
  attribute pin_type of G2BN is "input";

  Y0N : out std_logic;
  attribute pin_assign of Y0N is 15;
  attribute pin_type of Y0N is "output";
  Y1N : out std_logic;
  attribute pin_assign of Y1N is 14;
  attribute pin_type of Y1N is "output";
  Y2N : out std_logic;
  attribute pin_assign of Y2N is 13;
  attribute pin_type of Y2N is "output";
  Y3N : out std_logic;
  attribute pin_assign of Y3N is 12;
  attribute pin_type of Y3N is "output";
  Y4N : out std_logic;
  attribute pin_assign of Y4N is 11;
  attribute pin_type of Y4N is "output";
  Y5N : out std_logic;
  attribute pin_assign of Y5N is 10;
  attribute pin_type of Y5N is "output";
  Y6N : out std_logic;
  attribute pin_assign of Y6N is 9;
  attribute pin_type of Y6N is "output";
  Y7N : out std_logic;
  attribute pin_assign of Y7N is 8;
  attribute pin_type of Y7N is "output"
	);
	end ic74138;

architecture logic of ic74138 is 
  component comp74138
    port (
      A :  IN  STD_LOGIC;
      B :  IN  STD_LOGIC;
      C :  IN  STD_LOGIC;
      G1 :  IN  STD_LOGIC;
      G2AN :  IN  STD_LOGIC;
      G2BN :  IN  STD_LOGIC;
      Y0N :  OUT  STD_LOGIC;
      Y1N :  OUT  STD_LOGIC;
      Y2N :  OUT  STD_LOGIC;
      Y3N :  OUT  STD_LOGIC;
      Y4N :  OUT  STD_LOGIC;
      Y5N :  OUT  STD_LOGIC;
      Y6N :  OUT  STD_LOGIC;
      Y7N :  OUT  STD_LOGIC
    );
  end component;

begin 

  inst : comp74138
    port map (
      A => A,
      B => B, 
      C => C, 
      G1 => G1, 
      G2AN => G2AN, 
      G2BN => G2BN, 
      Y0N => Y0N,
      Y1N => Y1N,
      Y2N => Y2N,
      Y3N => Y3N,
      Y4N => Y4N,
      Y5N => Y5N,
      Y6N => Y6N,
      Y7N => Y7N
    );

end logic;