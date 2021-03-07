library IEEE;
use IEEE.std_logic_1164.all; 

entity ic4053mux is 
port
	(
		attribute library_name : string;
		attribute component_name : string;
		attribute footprint_name : string;
		attribute const_assign : string;
		attribute pin_assign : integer;

		attribute library_name of ic4053mux is "4xxx";
		attribute component_name of ic4053mux is "4053";
		attribute footprint_name of ic4053mux is "Package_DIP:DIP-16_W7.62mm_Socket_LongPads";

		VSS : in std_logic;
		attribute const_assign of VSS is "GND";
		attribute pin_assign of VSS is 8;
		attribute pin_type of VSS is "power_in";
		VEE : in std_logic;
		attribute const_assign of VEE is "GND";
		attribute pin_assign of VEE is 7;
		attribute pin_type of VEE is "power_in";
		VDD : in std_logic;
		attribute const_assign of VDD is "VCC";
		attribute pin_assign of VDD is 16;
		attribute pin_type of VDD is "power_in";
		INH : in std_logic;
		attribute const_assign of INH is "GND";
		attribute pin_assign of INH is 6;
		attribute pin_type of INH is "input";

		X0 : in std_logic;
		attribute pin_assign of X0 is 12;
		attribute pin_type of X0 is "input";
		X1 : in std_logic;
		attribute pin_assign of X1 is 13;
		attribute pin_type of X1 is "input";
		A : in std_logic;
		attribute pin_assign of A is 11;
		attribute pin_type of A is "input";
		X_COM : out std_logic;
		attribute pin_assign of X_COM is 14;
		attribute pin_type of X_COM is "output";

		Y0 : in std_logic;
		attribute pin_assign of Y0 is 2;
		attribute pin_type of Y0 is "input";
		Y1 : in std_logic;
		attribute pin_assign of Y1 is 1;
		attribute pin_type of Y1 is "input";
		B : in std_logic;
		attribute pin_assign of B is 10;
		attribute pin_type of B is "input";
		Y_COM : out std_logic;
		attribute pin_assign of Y_COM is 15;
		attribute pin_type of Y_COM is "output";

		Z0 : in std_logic;
		attribute pin_assign of Z0 is 5;
		attribute pin_type of Z0 is "input";
		Z1 : in std_logic;
		attribute pin_assign of Z1 is 3;
		attribute pin_type of Z1 is "input";
		C : in std_logic;
		attribute pin_assign of C is 9;
		attribute pin_type of C is "input";
		Z_COM : out std_logic;
		attribute pin_assign of Z_COM is 4;
		attribute pin_type of Z_COM is "output"
	);
end ic4053mux;

architecture logic of ic4053mux is 

	component mux21
		port(S : in std_logic;
			A : in std_logic;
			B : in std_logic;
			Y : out std_logic);
	end component;

begin 

	mux0 : mux21
	port MAP(
			S => A,
			A => X0,
			B => X1,
			Y => X_COM);

	mux1 : mux21
	port MAP(
			S => B,
			A => Y0,
			B => Y1,
			Y => Y_COM);
			
	mux2 : mux21
	port MAP(
			S => C,
			A => Z0,
			B => Z1,
			Y => Z_COM);

end logic;